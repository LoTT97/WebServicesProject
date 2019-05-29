import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { DeleteClubComponent } from 'src/app/delete-club/delete-club.component';
import { NewClubComponent } from 'src/app/new-club/new-club.component';

const routes: Routes = [
    {
        path: '',
        component: DashboardComponent
    },
    {
      path: 'delete-club/:ClubId',
      component: DeleteClubComponent
    },
    {
      path: 'new-club',
      component: NewClubComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class DashboardRoutingModule {}
