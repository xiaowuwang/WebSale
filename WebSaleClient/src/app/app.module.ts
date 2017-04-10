import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ProductComponent } from './product/product.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductListHeaderComponent } from './product-list-header/product-list-header.component';
import { ProductService } from "app/product.service";

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    ProductComponent,
    ProductListComponent,
    ProductListHeaderComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule
  ],

  providers: [ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
