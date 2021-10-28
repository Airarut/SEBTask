export class ExchangeDto {
    baseCurrency : string;
    currencyInformation : CurrencyDto[];

  }

export class CurrencyDto {
    currencyShortCode : string;
    changeOfRate : number;
    currentDateRate : number;
    previousDateRate : number;

}