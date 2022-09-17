import { Component, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutModule } from './layout/layout.module';
import { CustomersModule } from './components/customers/customers.module';
import { ComponentsModule } from './components/components.module';
import { CustomersComponent } from './customers/customers.component';



@NgModule({
  declarations: [
    
  
    CustomersComponent
  ],
  imports: [
    CommonModule,
    LayoutModule,
    CustomersModule,
    ComponentsModule 
  ],
  exports:[
    LayoutModule
  ]
})
export class AdminModule { }
