import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatButtonModule, MatCardModule, MatIconModule, MatTableModule, MatInputModule, MatCheckboxModule, MatSelectModule, MatToolbarModule, MatDialogModule, MatListModule } from '@angular/material';
import { MatGridListModule } from '@angular/material/grid-list';

import { StatModule } from '../../shared/modules/stat/stat.module';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { DeleteClubComponent } from '../../delete-club/delete-club.component';
import { UpdateClubComponent } from '../../update-club/update-club.component';
import { NewClubComponent } from '../../new-club/new-club.component';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { OverlayModule } from '@angular/cdk/overlay';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { createTranslateLoader } from 'src/app/app.module';
import { HttpClient } from 'selenium-webdriver/http';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';




@NgModule({

    imports: [
        CommonModule,
        DashboardRoutingModule,
        MatGridListModule,
        StatModule,
        MatIconModule,
        FlexLayoutModule.withConfig({addFlexToParent: false}),
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        LayoutModule,
        OverlayModule,
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: createTranslateLoader,
                deps: [HttpClient]
            }
        }),
        HttpClientModule,
        MatButtonModule, MatTableModule, MatInputModule, MatCheckboxModule,
        MatCardModule, MatSelectModule, MatToolbarModule,
        MatDialogModule, MatListModule,
        ReactiveFormsModule, FormsModule,
    ],
    entryComponents: [UpdateClubComponent],
    declarations: [DashboardComponent, DeleteClubComponent, NewClubComponent, UpdateClubComponent]
})
export class DashboardModule {}
