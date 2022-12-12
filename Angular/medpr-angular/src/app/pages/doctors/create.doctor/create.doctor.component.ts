import { ToastrService } from 'ngx-toastr';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Guid } from 'guid-typescript';
import { Doctor } from 'src/app/models/doctor';
import { DoctorsService } from 'src/app/services/doctors/doctors.service';
import { DoctorsActionsService } from 'src/app/services/doctors/doctors.actions.service';

@Component({
  selector: 'create-doctor',
  templateUrl: './create.doctor.component.html',
  styleUrls: ['./create.doctor.component.scss']
})
export class CreateDoctorComponent implements OnInit {
  @Output() deselect = new EventEmitter<void>();
  showSpinner: boolean = false;
  errorMessage?: string;

  constructor(private fb: FormBuilder,
    private doctorsService: DoctorsService,
    private toastr: ToastrService,
    private actions: DoctorsActionsService) { }

  ngOnInit(): void {
  }

  doctorForm = this.fb.group({
    name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(15)]],
    experience: ['', [Validators.required, Validators.min(0), Validators.max(100)]],
  });

  submit(){
    if (!this.showSpinner && this.doctorForm.valid){
      this.showSpinner = true;
      const doctor: Doctor = {
        id: Guid.createEmpty().toString(),
        name: this.doctorForm.value.name!,
        experience: Number(this.doctorForm.value.experience!)
      };
      this.doctorsService.create(doctor).pipe().subscribe({
        next: (doctor) => {
          this.showSpinner = false;
          this.actions.emitDoctorResponse(doctor);
          this.toastr.success(`Created`,`${doctor.name} is now in the app`);
          this.deselect.emit();
        },
        error: (err) => {
          this.showSpinner = false;
          console.log(err);
          this.toastr.success(`Failed`,`${doctor.name} is still in your dreams`);
          this.errorMessage = "Could not create doctor";
        },
      });
    }
  }

  cancel() {
    if(!this.showSpinner){
      this.doctorForm.reset();
    }
  }

  closeCreate(){
    if (!this.showSpinner){
      this.deselect.emit();
    }
  }
}
