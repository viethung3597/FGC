import { Component, OnInit } from '@angular/core';
import { purchaseOrderDetailService } from "../shared/services/purchase-order-detail.service";
import { salesOrderDetail } from "../shared/services/sales-order-detail.service";
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  filter: any = {
    fromDate: "",
    toDate: ""
  };

  chartDataSource!: DataSource;
  startDate: any;
  endDate: any;
  pageIndex: any;
  pageSize: any;

  constructor(public service: salesOrderDetail) {

  }

  ngOnInit(): void {
    this.filter.fromDate = "2013-04-09T00:00:00";
    this.filter.toDate = "2013-04-30T00:00:00";
    this.pageSize = 10;
    this.pageIndex = 1;

    // this.chartDataSource = new DataSource({
    //   store: new CustomStore({
    //     load: (options) => {
    //       options.take = this.pageSize;
    //       options.skip = ((this.pageIndex - 1) * this.pageSize);
    //       return this.service.getData(this.filter.fromDate, this.filter.toDate, this.pageIndex, this.pageSize);
    //     }
    //   }),
    //   paginate: true,
    //   pageSize: 10
    // });

    // console.log(this.service.purchaseOrderDetail);

    this.chartDataSource = new DataSource({
      store: new CustomStore({
        load: (options) => {
          options.take = this.pageSize;
          options.skip = ((this.pageIndex - 1) * this.pageSize);
          return this.service.getDataSale(this.filter.fromDate, this.filter.toDate, this.pageIndex, this.pageSize);
        }
      }),
      paginate: true,
      pageSize: 10
    });

    console.log(this.service.salesOrderDetail);

  }

  onChange(e: any) {
    this.chartDataSource.load();
  }

}
