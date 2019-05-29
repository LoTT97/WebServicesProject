import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ClubService } from '../shared/services/club.service';

@Component({
  selector: 'app-update-club',
  templateUrl: './update-club.component.html',
  styleUrls: ['./update-club.component.scss']
})
export class UpdateClubComponent implements OnInit {
  form: FormGroup;
  Id: number;

  // tslint:disable-next-line:max-line-length
  constructor(private fb: FormBuilder, private dialogRef: MatDialogRef<UpdateClubComponent>, @Inject(MAT_DIALOG_DATA) {ClubName, Location, Motto, EstablishedDate, ClubId},
              private service: ClubService) {
                this.Id = ClubId;
                this.form = fb.group(
                  {
                    ClubName: [ClubName, Validators.required],
                    Location: [Location, Validators.required],
                    Motto: [Motto, Validators.required],
                    EstablishedDate: [EstablishedDate, Validators.required]
                  }
                );
               }
  close() {
    this.dialogRef.close();
  }

  save() {
    this.form.value.id = this.Id;
    this.service.updateClub(this.Id, this.form.value).subscribe(
      (data) => {
        console.warn(data);
      }
    );
  }

  ngOnInit() {
  }

}
