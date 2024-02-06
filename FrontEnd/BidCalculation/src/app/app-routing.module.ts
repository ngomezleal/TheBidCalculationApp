import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BidCalculationComponent } from './bid/bid-calculation/bid-calculation.component';

const routes: Routes = [
  {
    path: '', 
    component: BidCalculationComponent, 
    pathMatch: 'full'
  },
  {
    path: '**',
    redirectTo: '',
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
