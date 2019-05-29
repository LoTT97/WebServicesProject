import {Member} from './Member';

export interface Competition {
  Name: string;
  Location: string;
  StartDate: string;
  EndDate: string;
  Description: string;
  Members: Array<Member>;
}
