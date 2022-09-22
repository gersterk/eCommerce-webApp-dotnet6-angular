import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';

@Component({
  selector: 'app-components',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.scss']
})
export class CostumersComponent extends  BaseComponent implements OnInit {

  constructor( spinner: NgxSpinnerService) { 
    super (spinner)
  }

  ngOnInit(): void {
    this.showSpinner(SpinnerType.ballAtom);
  }

}
