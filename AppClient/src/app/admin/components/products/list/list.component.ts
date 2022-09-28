import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinner, NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { List_Product } from 'src/app/contracts/list_products';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { ProductService } from 'src/app/services/common/models/product.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponentv extends BaseComponent implements OnInit {

  constructor(spinner : NgxSpinnerService,private productService: ProductService, private alertifyService : AlertifyService) {
    super(spinner)

   }
 displayedColumns: string[] = ['name', 'stock', 'price', 'createDate', 'updateDate'];
 dataSource : MatTableDataSource<List_Product>= null;

  ngOnInit(): void {
    this.showSpinner(SpinnerType.ballAtom);
    
    this.productService.read(()=>this.hideSpinner(SpinnerType.ballAtom), errorMessage => this.alertifyService.message(errorMessage, {
      dismissOthers: true,
      messageType: MessageType.Error,
      position : Position.TopRight
    }))
  }

}

