import {Club} from './Club';
import {Competition} from './Competition';
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
