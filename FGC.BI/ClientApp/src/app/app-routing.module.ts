import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetailComponent } from './detail/detail.component';
import { HomeComponent } from './home/home.component';
import { OrderQtyComponent } from './shared/components/order-qty/order-qty.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'detail', component: DetailComponent },
  { path: 'order-qty', component: OrderQtyComponent}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
