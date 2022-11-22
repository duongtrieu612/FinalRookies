import Gender from "src/constants/gender";

export default interface IUserForm {
  userId?: number;
  firstName: string;
  lastName: string;
  dateOfBirth?: Date;
  gender: string;
  joinedDate?: Date;
  type: string;
}
