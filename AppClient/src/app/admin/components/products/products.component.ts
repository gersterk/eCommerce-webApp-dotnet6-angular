 import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { Product } from 'src/app/contracts/product';
import { HttpClientService } from 'src/app/services/common/http-client.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent extends BaseComponent implements OnInit {

  constructor(spinner : NgxSpinnerService, private  httpClientService : HttpClientService) {
    super(spinner);
   }

  ngOnInit(): void {
    this.showSpinner(SpinnerType.ballAtom);

    this.httpClientService.get<Product []>({
      controller: "products"
    }).subscribe(data=> console.log(data));

    // this.httpClientService.delete({
    //   controller : "products"
    // },"5af96ac6-3814-4af6-9e09-d4ac63f1d0f1").subscribe();
    // this.httpClientService.post({

    //   controller : "products"

    // },{
    //   name  : "pencil",
    //   price: 20,
    //   stock : 100

    // }).subscribe();

    // this.httpClientService.put({
    //   controller : "products",
    // },{
    //   id: "6b741440-8028-4887-9697-d6b0573b05e4",
    //   name: "colorful pencil",
    //   stock: 1500,
    //   price : 5.4

    // }).subscribe()

    //
    // this.httpClientService.get({
    //   fullEndPoint: "https://jsonplaceholder.typicode.com/posts",
    // }).subscribe(data => console.log(data));
   }
  }

