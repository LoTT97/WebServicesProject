import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import { MatFormField, MatFormFieldModule, MatInput, MatInputModule } from '@angular/material';

const routes: Routes = [
    {
        path: '',
        component: DashboardComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes), MatFormFieldModule, MatInputModule],
    exports: [RouterModule, MatFormFieldModule, MatInputModule]
})
export class DashboardRoutingModule {}
