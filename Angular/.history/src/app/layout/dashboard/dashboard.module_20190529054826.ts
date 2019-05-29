import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
// tslint:disable-next-line:max-line-length
import { MatButtonModule, MatCardModule, MatIconModule, MatToolbarModule, MatSelectModule, MatDialogModule, MatListModule } from '@angular/material';
import { MatGridListModule } from '@angular/material/grid-list';

import { StatModule } from '../../shared/modules/stat/stat.module';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';

import { MatTableModule } from '@angular/material';
import { MatFormFieldModule, MatPaginatorModule } from '@angular/material';
import { MatInputModule } from '@angular/material';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
    imports: [
      MatTableModule,
      ReactiveFormsModule,
    MatToolbarModule, MatSelectModule,
    MatDialogModule, MatListModule,
        CommonModule,
        DashboardRoutingModule,
        MatGridListModule,
        StatModule,
        MatCardModule,
        MatTableModule,
        MatButtonModule,
        MatIconModule,
        MatFormFieldModule,
        MatInputModule,
        MatPaginatorModule,
        FlexLayoutModule.withConfig({addFlexToParent: false})
    ],
    exports: [MatFormFieldModule, MatInputModule],
    declarations: [DashboardComponent]
})
export class DashboardModule {}
