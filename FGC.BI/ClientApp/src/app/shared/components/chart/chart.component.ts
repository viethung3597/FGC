import { Component, Input, OnInit } from '@angular/core';
import { purchaseOrderDetailService } from "../../services/purchase-order-detail.service";
import { Router } from '@angular/router'; 

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent implements OnInit {
  @Input() dataSource:any ; 
  @Input() dataFilter:any ; 
  idSelect! : any;
  
  constructor(public service: purchaseOrderDetailService , private router: Router) {
  
  }

  ngOnInit(): void {
    
  } //end void

  name! : string;
  onClickTest(e: any) {
    var info = e.target;
    
    if (info.series.index == 0) {
      
      this.name = "receivedQty" ;
      
    } 
    if (info.series.index == 1) {

      this.name = "reorderPoint" ;

    } 
    if (info.series.index == 2) {

      this.name = "safetyStockLevel" ;

    } 
    //window.location.href = '/detail';
   this.router.navigate(['/detail'], { queryParams: { productID: info.data.productID, name: this.name , startDate : this.dataFilter.fromDate , endDate : this.dataFilter.toDate} });
  }
}
