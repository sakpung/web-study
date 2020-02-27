// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Filters {   
    export class PluralizeFilter {
        public static Factory() {
            return function (ordinal: number, noun: string):string {
                if (ordinal == 1) {
                    return ordinal + ' ' + noun;
                } else {
                    var plural = noun;
                    if (noun.substr(noun.length - 2) == 'us') {
                        plural = plural.substr(0, plural.length - 2) + 'i';
                    } else if (noun.substr(noun.length - 2) == 'ch' || noun.charAt(noun.length - 1) == 'x' || noun.charAt(noun.length - 1) == 's') {
                        plural += 'es';
                    } else if (noun.charAt(noun.length - 1) == 'y' && ['a', 'e', 'i', 'o', 'u'].indexOf(noun.charAt(noun.length - 2)) == -1) {
                        plural = plural.substr(0, plural.length - 1) + 'ies';
                    } else if (noun.substr(noun.length - 2) == 'is') {
                        plural = plural.substr(0, plural.length - 2) + 'es';
                    } else {
                        plural += 's';
                    }
                    return ordinal + ' ' + plural;
                }
            }
        }
    }
} 

filters.filter('pluralize', Filters.PluralizeFilter.Factory);