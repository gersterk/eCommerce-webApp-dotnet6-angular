 import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
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

    this.httpClientService.get({
      controller: "products"
    }).subscribe(data=> console.log(data));

    this.httpClientService.post({

      controller : "products"

    },{
      name  : "pencil",
      price: 20,
      stock : 100

    }).subscribe();


    this.httpClientService.post({

      controller : "products"

    },{
      name  : "book",
      price: 50,
      stock : 10

    }).subscribe();


    this.httpClientService.post({

      controller : "products"

    },{
      name  : "pc",
      price: 2000,
      stock : 15

    }).subscribe();
  }

}
