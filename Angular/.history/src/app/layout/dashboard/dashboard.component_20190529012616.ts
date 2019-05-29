import { Component, OnInit } from '@angular/core';
import { MatTableDataSource, MatDialog } from '@angular/material';
import { ClubService } from 'src/app/shared/services/club.service';
import { Club } from 'src/app/interfaces/Club';
import { UpdateClubComponent } from 'src/app/update-club/update-club.component';

export interface PeriodicElement {
    name: string;
    position: number;
    weight: number;
    symbol: string;
}

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
    displayedColumns: string[] =  ['ClubName', 'Location', 'Motto', 'EstablishedDate', 'Actions'];
    dataSource;

    applyFilter(filterValue: string) {
        filterValue = filterValue.trim(); // Remove whitespace
        filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches
        this.dataSource.filter = filterValue;
    }

    constructor(private service: ClubService, private dialog: MatDialog) {}

    ngOnInit() {
      this.service.getAll().subscribe((data) => {
        console.log(data);
        this.dataSource = new MatTableDataSource<Club>(data as Club[]);
      });
    }
    updateClub(club) {
      console.log(club);
      this.dialog.open(UpdateClubComponent, {
        data: {
          ClubName: club.ClubName,
          Location: club.Location,
          Motto: club.Motto,
          EstablishedDate: club.EstablishedDate,
          ClubId: club.ClubId
        }
      });
    }


}
