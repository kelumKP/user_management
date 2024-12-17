import { Box, Button, TextField, FormControl, MenuItem } from "@mui/material";
import { useForm, Controller } from "react-hook-form";
import { FormStyles } from "../../App.styles";
import SelectComponent from "../../components/form/SelectComponent";
import { User } from "../../state/types";
import { dictionary } from "../../utils/dictionary";

interface Props {
    user: User;
    // Role structure passed from parent
    roles?: { key: string; label: string; value: string }[];
    onSubmit: (data: User) => void;
}

const EditForm = ({ user, roles = [], onSubmit }: Props) => {
    const { control, register, handleSubmit, formState: {errors}} = useForm<User>(
      {
        defaultValues: user
      });

    return(
            <Box>
                <form id="register-form" onSubmit={handleSubmit(onSubmit)}>
                <Box>
                    <FormControl fullWidth>
                        <TextField
                            label="Username"
                            placeholder="Username"
                            {...register("username", { required: true })}
                            error={errors.username !== undefined}
                            helperText={errors.username?.message !== undefined ? dictionary.formErrors.required : ""}
                        />
                    </FormControl>
                </Box>
                <Box sx={FormStyles.fieldBox}>
                    <FormControl fullWidth>
                        <TextField
                            label="Email address"
                            placeholder="Email address"
                            {...register("email", { required: true })}
                            error={errors.email !== undefined}
                            helperText={errors.email?.message !== undefined ? dictionary.formErrors.required : ""}
                        />
                    </FormControl>
                </Box>
                <Box sx={{textAlign: "left", ...FormStyles.fieldBox}}>
                <FormControl fullWidth>
                      <Controller name="role" control={control} rules={{ required: "Account type is required" }} render={({ field }) => (
                        <TextField select label="Account Type" {...field} error={!!errors.role} helperText={errors.role?.message || ""} >
                           {roles.length === 0 ? ( <MenuItem disabled>No roles available</MenuItem>) : ( roles.map(({ key, label, value }) => ( <MenuItem key={key} value={value}>{label} </MenuItem> )))}
                        </TextField>
                      )}/>
                </FormControl>
                </Box>
                <Box sx={FormStyles.fieldBox}>
                    <Button type="submit" sx={FormStyles.field} variant="contained">Save user</Button>
                </Box>
                </form>
            </Box>
    )

}


export default EditForm;