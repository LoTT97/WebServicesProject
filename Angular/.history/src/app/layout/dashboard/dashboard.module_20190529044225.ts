import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatButtonModule, MatCardModule, MatIconModule, MatTableModule } from '@angular/material';
import { MatGridListModule } from '@angular/material/grid-list';

import { StatModule } from '../../shared/modules/stat/stat.module';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { DeleteClubComponent } from '../../delete-club/delete-club.component';
import { UpdateClubComponent } from '../../update-club/update-club.component';
import { NewClubComponent } from '../../new-club/new-club.component';




@NgModule({

    imports: [
        CommonModule,
        DashboardRoutingModule,
        MatGridListModule,
        StatModule,
        MatCardModule,
        MatCardModule,
        MatTableModule,
        MatButtonModule,
        MatIconModule,
        FlexLayoutModule.withConfig({addFlexToParent: false})
    ],
    entryComponents: [UpdateClubComponent],
    declarations: [DashboardComponent, DeleteClubComponent, NewClubComponent]
})
export class DashboardModule {}
