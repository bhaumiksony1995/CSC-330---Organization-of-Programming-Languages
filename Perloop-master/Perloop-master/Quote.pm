#!/usr/bin/perl

package Quote;

use strict;

sub new {

      my $class = shift;
        my $self = {};
          return bless $self, $class;
      }

      sub set_phrase {
            my $self = shift;
              my $phrase = shift;
                $self->{phrase} = $phrase;
            }

            sub get_phrase {
                  my $self = shift;
                    return $self->{phrase};
                }

                sub set_author {
                      my $self = shift;
                        my $author = shift;
                          $self->{author} = $author;
                      }

                      sub get_author {
                            my $self = shift;
                              return $self->{author};
                          }

                          sub is_approved {
                                my $self = shift;
                                  @_ ? $self->{_approved} = shift : $self->{_approved};
                              }

                              1;
