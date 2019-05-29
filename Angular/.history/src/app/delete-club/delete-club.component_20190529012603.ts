import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClubService } from '../shared/services/club.service';

@Component({
  selector: 'app-delete-club',
  templateUrl: './delete-club.component.html',
  styleUrls: ['./delete-club.component.scss']
})
export class DeleteClubComponent implements OnInit {

  constructor(private route: ActivatedRoute, private service: ClubService, private router: Router) { }

  ClubId;
  club = {
    ClubName: '',
    Location: '',
    Motto: '',
    EstablishedDate: ''
  };
  ngOnInit() {
    this.ClubId = this.route.snapshot.paramMap.get('ClubId');
    this.service.getClub(this.ClubId).subscribe(
      (data: any) => {
        this.club.ClubName = data.ClubName;
        this.club.Location = data.Location;
        this.club.Motto = data.Motto;
        this.club.EstablishedDate = data.EstablishedDate;
      }
    );
  }

  close() {
    this.router.navigate(['/dashboard']);
  }

  confirm() {
    this.service.deleteClub(this.ClubId).subscribe(
      (data) => {
        console.log('club deleted');
      }
    );

    alert('Deleted');
  }

}
