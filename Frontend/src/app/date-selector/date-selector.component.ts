import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { BackendService } from '../config/backend.service';
import { ExchangeDto } from './exchangeDto';


@Component({
  selector: 'app-date-selector',
  templateUrl: './date-selector.component.html',
  styleUrls: ['./date-selector.component.scss'],
  providers: [BackendService]
})
export class DateSelectorComponent implements OnInit {
   @Output() onSelected: EventEmitter<any> = new EventEmitter();
  date = new FormControl(new Date());
  minDate: Date = new Date('1999-01-01');
  maxDate: Date = new Date();
  exchangeRateDto : ExchangeDto;
  str: string;

  constructor(
    private backendService: BackendService,
    private datePipe: DatePipe,
  ) { }

  ngOnInit(): void {
    var newDate = this.datePipe.transform(this.date.value, 'yyyy-MM-dd');
    this.getData(newDate);
  }

  onSelect(day: MatDatepickerInputEvent<Date>): void{
    this.onSelected.emit(day.value);
    var newDate = this.datePipe.transform(day.value, 'yyyy-MM-dd');
    this.getData(newDate);
  }

  getData(day: string | null): void{
    this.backendService.GetRates(day).subscribe((data: any) => {
      this.exchangeRateDto = data as ExchangeDto;
      this.exchangeRateDto.currencyInformation = this.exchangeRateDto.currencyInformation.sort((a, b) => ( Math.abs(a.changeOfRate) >  Math.abs(b.changeOfRate) ? -1 : 1));
    });

  }
}
