import { LayoutModule } from '@angular/cdk/layout';
import { OverlayModule } from '@angular/cdk/overlay';
import { NgModule } from '@angular/core';
import {
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatSidenavModule,
    MatToolbarModule,
    MatButton,
    MatTableModule,
    MatInputModule,
    MatCardModule,
    MatSelectModule,
    MatDialog,
    MatDialogModule,
    MatCheckboxModule
} from '@angular/material';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { FlexLayoutModule } from '@angular/flex-layout';
import { UpdateClubComponent } from './update-club/update-club.component';
import { DeleteClubComponent } from './delete-club/delete-club.component';
import { AuthService } from './shared/services';
import { ClubService } from './shared/services/club.service';
import { CompetitionService } from './shared/services/competition.service';
import { MemeberService } from './shared/services/memeber.service';
import { NewClubComponent } from './new-club/new-club.component';
// AoT requires an exported function for factories
export const createTranslateLoader = (http: HttpClient) => {
    /* for development
    return new TranslateHttpLoader(
        http,
        '/start-javascript/sb-admin-material/master/dist/assets/i18n/',
        '.json'
    );*/
    return new TranslateHttpLoader(http, './assets/i18n/', '.json');
};

@NgModule({
    declarations: [AppComponent, RegisterComponent, UpdateClubComponent, DeleteClubComponent, NewClubComponent, TablesComponent],
    imports: [
        CommonModule,
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        LayoutModule,
        OverlayModule,
        HttpClientModule,
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
        FlexLayoutModule.withConfig({addFlexToParent: false})
    ],
    entryComponents: [UpdateClubComponent],
    providers: [AuthService, ClubService, CompetitionService, MemeberService],
    bootstrap: [AppComponent]
})
export class AppModule {}
