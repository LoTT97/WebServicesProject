import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { MatFormField } from '@angular/material';

const routes: Routes = [
    {
        path: '',
        component: DashboardComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes), MatFormFieldModule],
    exports: [RouterModule, MatFormFieldModule]
})
export class DashboardRoutingModule {}
