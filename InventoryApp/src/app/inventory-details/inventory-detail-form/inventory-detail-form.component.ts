import { Component } from '@angular/core';
import { InventoryItemService } from 'src/app/shared/inventory-detail.service';
import { NgForm } from "@angular/forms";
import { InventoryItem } from 'src/app/shared/inventory-detail.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-inventory-detail-form',
  templateUrl: './inventory-detail-form.component.html',
  styles: [
  ]
})
export class InventoryItemFormComponent {

  constructor(public service: InventoryItemService, private toastr: ToastrService) {
  }

  onSubmit(form: NgForm) {
    this.service.formSubmitted = true
    if (form.valid) {
      if (this.service.formData.itemID == 0)
        this.insertRecord(form)
      else
        this.updateRecord(form)
    }

  }

  insertRecord(form: NgForm) {
    this.service.postInventoryDetail()
      .subscribe({
        next: res => {
          this.service.list = res as InventoryItem[]
          this.service.resetForm(form)
          this.toastr.success('Inserted successfully', 'Inventory Detail Register')
        },
        error: err => { console.log(err) }
      })
  }
  updateRecord(form: NgForm) {
    this.service.putInventoryDetail()
      .subscribe({
        next: res => {
          this.service.list = res as InventoryItem[]
          this.service.resetForm(form)
          this.toastr.info('Updated successfully', 'Inventory Detail Register')
        },
        error: err => { console.log(err) }
      })
   }

}
