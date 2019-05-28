import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MemeberService {
  baseURL = 'http://localhost:54010/api/members';

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get(this.baseURL);
  }
  getClub(id) {
    return this.http.get(this.baseURL + '/' + id);
  }
  createClub(member) {
    return this.http.post(this.baseURL, member);
  }
  updateClub(member, id) {
    return this.http.put(this.baseURL + '/' + id, member);
  }
  deleteClub(id) {
    return this.http.delete(this.baseURL + '/' + id);
  }
}
