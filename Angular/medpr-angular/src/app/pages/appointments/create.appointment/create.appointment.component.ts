import { map, Observable, of } from 'rxjs';
import { selectUserId } from './../../../store/app.states';
import { ToastrService } from 'ngx-toastr';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Guid } from 'guid-typescript';
import { Appointment } from 'src/app/models/appointment';
import { AppointmentsService } from 'src/app/services/appointments/appointments.service';

import { DoctorsService } from 'src/app/services/doctors/doctors.service';
import { Doctor } from 'src/app/models/doctor';
import { Store } from '@ngrx/store';
import { selectStateUser } from 'src/app/store/app.states';
import { MatOptionSelectionChange } from '@angular/material/core';

@Component({
  selector: 'create-appointment',
  templateUrl: './create.appointment.component.html',
  styleUrls: ['./create.appointment.component.scss'],
})
export class CreateAppointmentComponent implements OnInit {
  @Output() deselect = new EventEmitter<void>();
  doctors: Doctor[] = [];
  @Output() selectedDoctor = new EventEmitter<string>();
  userId?: string;
  doctorChange?: Observable<string | null | undefined>;

  showSpinner: boolean = false;
  errorMessage?: string;

  constructor(
    private fb: FormBuilder,
    private appointmentsService: AppointmentsService,
    private DoctorsService: DoctorsService,
    private store: Store,
    private toastr: ToastrService
  ) {
    this.doctorChange = of(this.appointmentForm.value.doctorId);
  }

  ngOnInit(): void {
    this.DoctorsService.getAllDoctors().subscribe(
      (doctors) => (this.doctors = doctors)
    );

    this.store.select(selectUserId).pipe()
      .subscribe((userId) => {
        this.userId = userId;
      });

      this.doctorChange?.pipe().subscribe(doctorId => {
        if(typeof doctorId === "string") {
          this.selectedDoctor.emit(doctorId);
        }
      })
  }

  appointmentForm = this.fb.group({
    date: ['', [Validators.required]],
    place: ['',[Validators.required, Validators.minLength(2), Validators.maxLength(30)],],
    doctorId: ['', [Validators.required]],
  });

  submit() {
    if (!this.showSpinner && this.appointmentForm.valid) {
      this.showSpinner = true;

      const appointment: Appointment = {
        id: Guid.createEmpty().toString(),
        date: new Date(this.appointmentForm.value.date!),
        place: this.appointmentForm.value.place!,
        userId: this.userId!,
        doctorId: this.appointmentForm.value.doctorId!,
      };

      this.appointmentsService
        .create(appointment)
        .pipe()
        .subscribe({
          next: () => {
            this.showSpinner = false;
            window.location.reload();
          },
          error: (err) => {
            this.showSpinner = false;
            console.log(err);
            this.errorMessage = 'Could not create appointment';
          },
        });
    }
  }

  cancel() {
    if (!this.showSpinner) {
      this.appointmentForm.reset();
    }
  }

  closeCreate() {
    if (!this.showSpinner) {
      this.deselect.emit();
    }
  }
}
