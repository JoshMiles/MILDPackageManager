#!/bin/bash
echo "Preparing to push changes."
git add *
echo -e "Enter a commit message:"
read commitmessage
git commit -m "$commitmessage"
echo "Press any key to commit with the message:"
echo $commitmessage
read randomshit
echo "Pushing to origin master."
git push origin master
echo "Done."