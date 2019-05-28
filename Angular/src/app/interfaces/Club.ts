import { Member } from './member';

export interface Club {
  ClubName: string;
  Motto: string;
  EstablishedDate: string;
  Members: Array<Member>;
}
