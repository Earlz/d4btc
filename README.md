# d4btc

d4btc is an autonomous bitcoin store for downloadable content. That's a pretty concise and accurate explanation... 

## Why am I making it?

Well, Bitcoin has this really amazing property. It doesn't require third parties to mess with, unlike credit cards or bank details. So, this is truly the only self-hosting store. It also can be very autonomous. After being setup, zero maintenance should be required other.

## Requirements

Currently, these are the requirements

1. Linux (sorry, no Windows testing right now)
2. mono 3.0+
3. PostgreSQL 9.0+ 
4. bitcoind/bitcoin-daemon

## Goals

Well, there's basically nothing here... So, here's the plan. 

1. Accept BTC (duh)
2. Be self-hosting with open source software and no dependencies (I've chose Mono, PostgreSQL and Linux)
3. BSD licensed.. because I want people to take this and build on it. The more bitcoin use the better!
4. Minimal risk

First, it will of course accept BTC. Initially, BTC with no auto adjustment for the US dollar

Second, I'm using (controversially?) mono. It's what I know and what I can build quickly in. If you have a problem, you can fork me (ha)

Third, None of that AGPL crap.

Fourth, minimal risk. Ideally, even zero risk. By minimal risk, I mean if an attacker gets root access to your server, nothing is lost other than some downtime to secure it. Store as little money in wallets as possible(flushed every 24 hours to external account). Store no usernames or passwords. Store no personal information. If an attacker gets root access, this is exactly what they are capable of stealing:

1. The bitcoins that haven't been flushed out (ideally, not much)
2. All downloadable content you are hosting (meh, it's probably on pirate bay already anyway)

They could possibly install malware into your site or some such, but you should have proper monitoring for that type of risk. That is unavoidable. 

## Compiling

There is a prebuild event to automatically regenerate the T4 view templates. If using Visual Studio, you can remove this Just make sure to run the T4 template ViewGenerator.tt when changing the HTML views. Under Linux, I expect for there to be the file /usr/local/bin/mono-t4. You must add this in yourself. The contents for most Linux distros is this:

    #!/bin/sh
    mono /usr/lib/monodevelop/AddIns/MonoDevelop.TextTemplating/TextTransform.exe -o $1 $2
Make sure to make it executable.


## Donations

If you feel like donating to motivate me, my address is 178DgR2aZcHeYHhXZwtvcJ5RD13Y6YMQBf. :)
