import { Component, OnInit } from '@angular/core';
import { ClubService } from '../shared/services/club.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-new-club',
  templateUrl: './new-club.component.html',
  styleUrls: ['./new-club.component.scss']
})
export class NewClubComponent {

  constructor(private service: ClubService, private router: Router) { }

  clubForm = new FormGroup(
    {
      ClubName: new FormControl(''),
      Location: new FormControl(''),
      Motto: new FormControl(''),
      EstablishedDate: new FormControl('')
    }
  );

  onSubmit() {
    console.log('Creating entry: ' + this.clubForm.value);
    this.service.createClub(this.clubForm.value).subscribe(
      (data) => {
        console.log('Result: ' + data);
      }
    );
    this.router.navigate(['/dashboard']);
  }
}
