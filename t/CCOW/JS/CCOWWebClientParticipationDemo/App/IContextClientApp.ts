// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************

module CcowWebClientParticipationDemo {
   export interface IContextClientApp {
      getSuffix(): string;
      getUserLink(): boolean;
      setUserLink(useLink: boolean): void;
      onContextTerminated(): void;
      onContextChangesAccepted(coupon: number): void;
      onContextChangesCanceled(coupon: number): void;
      onContextChangesPending(contextCoupon: number): void;
      joinedContext(context: ClientContext): void;
      leftContext(context: ClientContext): void;
      pinged(context: ClientContext): void;
      log(str: string, ...obj: Object[]): void;
   }
}