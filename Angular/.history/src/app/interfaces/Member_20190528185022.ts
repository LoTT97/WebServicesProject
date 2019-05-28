export interface Member {
  FirstName: string;
  LastName: string;
  DateOfBirth: Date;
  Height: number;
  Weight: number;
  Email: string;
  Phone: string;
  Club: Club;
  Competition: Array<Competition>;
}
