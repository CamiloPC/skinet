import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from './models/product';
import { IPagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{

  title = 'Skinet';
  products: IProduct[] = [];

  constructor (private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:7206/api/products?pagesize=50').subscribe((response: any) => {
      this.products = response.data;}, error => {console.log(error)});
  }
}
