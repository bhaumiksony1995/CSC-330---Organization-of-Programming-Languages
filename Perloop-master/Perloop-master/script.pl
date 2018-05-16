#!/usr/bin/perl

use strict;
use Quote;

my $phrase = "Baz";
my $author = "Foo";

my $quote = Quote->new();
$quote->set_phrase($phrase);
$quote->set_author($author);

print STDOUT $quote->get_phrase(), "\n";
print STDOUT $quote->get_author(), "\n";
print STDOUT ($quote->is_approved() ? "Is approved" : "Is not approved
    "), "\n";

exit 0;
