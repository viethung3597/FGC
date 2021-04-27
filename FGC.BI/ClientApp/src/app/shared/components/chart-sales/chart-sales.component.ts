import { Component, Input, OnInit } from '@angular/core';
import { salesOrderDetail } from "../../services/sales-order-detail.service";
import { Router } from '@angular/router'; 

@Component({
  selector: 'app-chart-sales',
  templateUrl: './chart-sales.component.html',
  styleUrls: ['./chart-sales.component.scss']
})
export class ChartSalesComponent implements OnInit {
  @Input() dataSource:any ; 
  @Input() dataFilter:any ; 
  idSelect! : any;
  constructor(public service: salesOrderDetail , private router: Router) { }

  ngOnInit(): void {
  }
  name! : string;
  onClickTest(e: any) {
    var info = e.target;
    console.log(info);
    //window.location.href = '/detail';
   this.router.navigate(['/order-qty'], { queryParams: { productID: info.data.productID,orderQty: info.data.orderQty , startDate : this.dataFilter.fromDate , endDate : this.dataFilter.toDate} });
  }
}
