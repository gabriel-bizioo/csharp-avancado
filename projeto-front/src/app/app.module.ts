import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import{RouterModule} from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { RegisterAddressComponent } from './register-address/register-address.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { WishListComponent } from './wish-list/wish-list.component';
import { PurchasesComponent } from './purchases/purchases.component';
import { PurchaseDetailComponent } from './purchase-detail/purchase-detail.component';
import { RegisterStoreComponent } from './register-store/register-store.component';
import { RegisterProductComponent } from './register-product/register-product.component';


@NgModule({
  declarations: [
    AppComponent,
    TopBarComponent,
    ProductListComponent,
    ProductDetailComponent,
    LoginComponent,
    RegisterComponent,
    RegisterAddressComponent,
    WishListComponent,
    PurchasesComponent,
    PurchaseDetailComponent,
    RegisterStoreComponent,
    RegisterProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      {path: '', component : ProductListComponent},
      // {path: 'product/:productID', component: ProductDetailComponent},
      {path: 'product', component: ProductDetailComponent},
      {path: 'login', component: LoginComponent},
      {path: 'register', component: RegisterComponent},
      {path: 'address-register', component:RegisterAddressComponent},
      {path: 'wishList', component:WishListComponent},
      {path: "purchases", component:PurchasesComponent},
      {path: "purchase-detail/:purchaseID", component:PurchaseDetailComponent},
      {path: 'store-register', component: RegisterStoreComponent},
      {path: 'product-register', component: RegisterProductComponent},
    ]),
    NoopAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
