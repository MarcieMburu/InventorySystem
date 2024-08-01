import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { InventoryDetail } from '../shared/inventory-detail.model';
import { InventoryDetailService } from '../shared/inventory-detail.service';

@Component({
  selector: 'app-inventory-details',
  templateUrl: './inventory-details.component.html',
  styles: [
  ]
})
export class InventoryDetailsComponent implements OnInit {

  constructor(public service: InventoryDetailService, private toastr: ToastrService) {
  }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: InventoryDetail) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?'))
      this.service.deleteInventoryDetail(id)
        .subscribe({
          next: res => {
            this.service.list = res as InventoryDetail[]
            this.toastr.error('Deleted successfully', 'Inventory Detail Register')
          },
          error: err => { console.log(err) }
        })
  }

}
