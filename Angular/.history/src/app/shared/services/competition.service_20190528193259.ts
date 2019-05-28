import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CompetitionService {

  baseURL = 'http://localhost:54010/api/competitions';

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get(this.baseURL);
  }
  getClub(id) {
    return this.http.get(this.baseURL + '/' + id);
  }
  createClub(competition) {
    return this.http.post(this.baseURL, competition);
  }
  updateClub(competition, id) {
    return this.http.put(this.baseURL + '/' + id, competition);
  }
  deleteClub(id) {
    return this.http.delete(this.baseURL + '/' + id);
  }
}
