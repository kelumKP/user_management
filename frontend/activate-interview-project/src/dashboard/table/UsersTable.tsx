import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import { User } from '../../state/types';
import UserRow from './UserRow';

interface Props {
    data: User[];
    setSelectedUser: (user: User | null) => void;
    refetch: () => void;
}

const cols = ["Id", "Username", "Email", "Is Admin", "Actions"];

const UsersTable = ({ data, setSelectedUser, refetch }: Props) => {
    return(
        <Table aria-label="Users table">
            <TableHead>
            <TableRow>
                {cols.map((col: string) => (
                    <TableCell key={col}>{col}</TableCell>
                ))}
            </TableRow>
            </TableHead>
            <TableBody>
                {data.map((user: User) => (
                    <UserRow key={user.id} refetch={refetch} user={user} setSelectedUser={setSelectedUser}/>
                ))}
            </TableBody>
        </Table>
    )
}

export default UsersTable;