#!/usr/bin/perl
use strict;
use Quote;

print STDOUT Quote::get_phrase(), "\n";
print STDOUT Quote::get_author(), "\n";
print STDOUT (Quote::is_approved() ? "Is approved" : "Is not approved"), "\n";

my $phrase = "Baz";
my $author = "Foo";

exit 0;
