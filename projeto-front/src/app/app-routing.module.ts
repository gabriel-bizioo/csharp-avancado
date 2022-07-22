import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { LoginComponent } from './login/login.component';
import { ProductListComponent } from './product-list/product-list.component';
import { RegisterComponent } from './register/register.component';
import { RegisterAddressComponent } from './register-address/register-address.component';
import { WishListComponent } from './wish-list/wish-list.component';
import { PurchasesComponent } from './purchases/purchases.component';
import { PurchaseDetailComponent } from './purchase-detail/purchase-detail.component';
import { RegisterStoreComponent } from './register-store/register-store.component';
import { RegisterProductComponent } from './register-product/register-product.component';

const routes: Routes = [ {path: '', component : ProductListComponent},
{path: 'product/:productID', component: ProductDetailComponent},
// {path: 'product', component: ProductDetailComponent},
{path: 'login', component: LoginComponent},
{path: 'register', component: RegisterComponent},
{path: 'address-register', component: RegisterAddressComponent},
{path: 'wishList', component: WishListComponent},
{path: 'purchases', component:PurchasesComponent},
{path: "purchase-detail/:purchaseID", component:PurchaseDetailComponent},
{path: 'store-register', component: RegisterStoreComponent},
{path: 'product-register', component: RegisterProductComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
