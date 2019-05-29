import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { DeleteClubComponent } from 'src/app/delete-club/delete-club.component';

const routes: Routes = [
    {
        path: '',
        component: DashboardComponent
    },
    {
      path: 'delete-club',
      component: DeleteClubComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class DashboardRoutingModule {}
