import { Member } from './member';

export interface Club {
  ClubName: string;
  Location: string;
  Motto: string;
  EstablishedDate: string;
  Members: Array<Member>;
}
