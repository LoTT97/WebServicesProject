import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ClubService {
  baseURL = 'http://localhost:54010/api/clubs';

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get(this.baseURL);
  }
  getClub(id) {
    return this.http.get(this.baseURL + '/' + id);
  }
  createClub(club) {
    return this.http.post(this.baseURL, club);
  }
  updateClub(club, id) {
    return this.http.put(this.baseURL + '/' + id, club);
  }
  deleteClub(id) {
    return this.http.delete(this.baseURL + '/' + id);
  }
}
