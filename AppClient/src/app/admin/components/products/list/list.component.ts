import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  constructor() { }
 displayedColumns: string[] = ['name', 'stock', 'price', 'createDate', 'updateDate'];
 dataSource : MatTableDataSource<{}>= null;

  ngOnInit(): void {
  }

}

