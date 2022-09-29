import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource, _MatTableDataSource } from '@angular/material/table';
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
export class ListComponent extends BaseComponent implements OnInit, AfterViewInit {

  constructor(spinner : NgxSpinnerService,private productService: ProductService, private alertifyService : AlertifyService) {
    super(spinner)

   }
  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;

  }
 displayedColumns: string[] = ['name', 'stock', 'price', 'createDate', 'updateDate'];
 dataSource : MatTableDataSource<List_Product>= null;
@ViewChild(MatPaginator) paginator : MatPaginator;

  async ngOnInit() {
    this.showSpinner(SpinnerType.ballAtom);
    
    const allProducts: List_Product[] = await this.productService.read(()=>this.hideSpinner(SpinnerType.ballAtom), errorMessage => this.alertifyService.message(errorMessage, {
      dismissOthers: true,
      messageType: MessageType.Error,
      position : Position.TopRight
    }))
    this.dataSource = new MatTableDataSource<List_Product>(allProducts);

  }

}

