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
  ClubId: number;

  // tslint:disable-next-line:max-line-length
  constructor(private fb: FormBuilder, private dialogRef: MatDialogRef<UpdateClubComponent>, @Inject(MAT_DIALOG_DATA) {ClubName, Location, Motto, EstablishedDate, ClubId},
              private service: ClubService) {
                this.ClubId = ClubId;
                this.form = fb.group(
                  {
                    ClubId: [ClubId],
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
    console.log('Form id: ' + this.form.value.ClubId);
    console.log('This id: ' + this.ClubId);
    this.form.value.ClubId = this.ClubId;
    this.service.updateClub(this.ClubId, this.form.value).subscribe(
      (data) => {
        console.warn(data);
      }
    );
  }

  ngOnInit() {
  }

}
