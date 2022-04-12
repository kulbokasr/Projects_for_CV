import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule, Routes } from '@angular/router';
import { ShopListComponent } from './components/shop-list/shop-list.component';
import { ShopCreateComponent } from './components/shop-create/shop-create.component';
import { UpdateShopComponent } from './components/update-shop/update-shop.component';

const routes: Routes = [
  { path: 'shop-create', component: ShopCreateComponent},
  { path: 'shop-list', component: ShopListComponent},
  { path: 'update-shop', component: UpdateShopComponent},
  { path: '',   redirectTo: '/shop-list', pathMatch: 'full' }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }