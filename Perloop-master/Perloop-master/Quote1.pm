#!/usr/bin/perl

package Quote;

use strict;

my $quote_ref = {
      phrase   => "Foo",
        author   => "Bar",
          approved => 1,
      };

      sub get_phrase {
            return $quote_ref->{phrase};
        }

        sub set_phrase {
              $quote_ref->{phrase} = shift;
          }

          sub get_author {
                return $quote_ref->{author};
            }

            sub set_author {
                  $quote_ref->{author} = shift;
              }

              sub is_approved {
                    return $quote_ref->{approved};
                }

                1;
