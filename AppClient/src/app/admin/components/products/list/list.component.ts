import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { List_Product } from 'src/app/contracts/list_products';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  constructor() { }
 displayedColumns: string[] = ['name', 'stock', 'price', 'createDate', 'updateDate'];
 dataSource : MatTableDataSource<List_Product>= null;

  ngOnInit(): void {
  }

}

