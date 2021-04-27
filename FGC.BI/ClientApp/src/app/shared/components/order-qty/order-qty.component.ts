import { Component, OnInit } from '@angular/core';
import { salesOrderDetail } from "../../services/sales-order-detail.service";
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';
import { ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/filter';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order-qty',
  templateUrl: './order-qty.component.html',
  styleUrls: ['./order-qty.component.scss']
})
export class OrderQtyComponent implements OnInit {
  startDate: any;
  endDate: any;
  pageIndex: any;
  pageSize: any;
  chartDataSource!: DataSource;
  productID!: string;
  value!: string;
  constructor(public service: salesOrderDetail, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.startDate = "2012-01-01T00:00:00";
    this.endDate = "2014-02-02T00:00:00";
    this.pageSize = 10;
    this.pageIndex = 1;

    this.route.queryParams
      .filter(params => params.productID)
      .subscribe(params => {

        this.productID = params.productID;
        this.startDate = params.startDate;
        this.endDate = params.endDate;

        this.chartDataSource = new DataSource({
          store: new CustomStore({
            load: (options) => {
              return this.service.getDataId(this.startDate, this.endDate, this.productID);
            }
          }),
          paginate: true,
          pageSize: 10
        });

      }
      );
  }

  onBack(e: any) {
    this.router.navigate(['']);
  }
}
