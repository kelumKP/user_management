import { Box, Card, Tab, Tabs, Typography } from "@mui/material";
import useAxios from "axios-hooks";
import { useGetAuthenticatedUser } from "../services/Auth.Service";
import { DashboardStyles } from "./Styles";
import UsersTable from "./table/UsersTable";
import { useState } from "react";
import UserDialog from "./dialog/EditUserDialog";
import { User } from "../state/types";
import { buildUrl } from "../utils/EndpointProvider";

const Dashboard = () => {
    const user = useGetAuthenticatedUser();
    const [selectedUser, setSelectedUser] = useState<User| null>(null);
    const [tabIndex, setTabIndex] = useState(0);
  
    const [{ data: allUsers, loading: loadingAll }, refetchAll] = useAxios(
      {
        url: buildUrl('user'),
        method: 'GET',
        withCredentials: true,
      },
      { manual: false }
    );
  
    const [{ data: adminUsers, loading: loadingAdmin }, refetchAdmin] = useAxios(
      {
        url: buildUrl('user/admin'),
        method: 'GET',
        withCredentials: true,
      },
      { manual: false }
    );
  
    const [{ data: regularUsers, loading: loadingRegular }, refetchRegular] = useAxios(
      {
        url: buildUrl('user/normal'),
        method: 'GET',
        withCredentials: true,
      },
      { manual: false }
    );
  
    const handleTabChange = (event: any, newValue: number) => {
      setTabIndex(newValue);
    };
  
 // Refetch all data when a user is updated in the dialog
  const handleUserUpdate = () => {
    refetchAll();
    refetchAdmin();
    refetchRegular();
  };

    const renderUsersTable = () => {
      if (tabIndex === 0 && !loadingAll && allUsers) {
        return (
          <UsersTable
            refetch={refetchAll}
            data={allUsers}
            setSelectedUser={setSelectedUser}
          />
        );
      } else if (tabIndex === 1 && !loadingAdmin && adminUsers) {
        return (
          <UsersTable
            refetch={refetchAdmin}
            data={adminUsers}
            setSelectedUser={setSelectedUser}
          />
        );
      } else if (tabIndex === 2 && !loadingRegular && regularUsers) {
        return (
          <UsersTable
            refetch={refetchRegular}
            data={regularUsers}
            setSelectedUser={setSelectedUser}
          />
        );
      }
      return null;
    };
  
    return (
      <>
        <Box sx={{ width: '100%' }}>
          <Typography variant="h4">{`Welcome to the dashboard, ${user?.username}!`}</Typography>
          <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
            <Tabs value={tabIndex} onChange={handleTabChange} aria-label="user tabs">
              <Tab label="ALL" />
              <Tab label="ADMIN USERS" />
              <Tab label="NORMAL USERS" />
            </Tabs>
          </Box>
          <Card>
            {renderUsersTable()}
          </Card>
        </Box>
        <UserDialog
          selectedUser={selectedUser}
          onClose={() => setSelectedUser(null)}
          refetch={handleUserUpdate}
        />
      </>
    );
  };

export default Dashboard;